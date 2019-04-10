using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Senai.WebApi.Wishlist {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddJsonOptions(
                opt => {
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
             ).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddAuthentication();

            services.AddAuthentication(
                i => {
                    i.DefaultAuthenticateScheme = "JwtBearer";
                    i.DefaultChallengeScheme = "JwtBearer";
                }
            ).AddJwtBearer("JwtBearer", v => {
                v.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidIssuer = "Wishlist.WebApi",

                    ValidateActor = true,
                    ValidAudience = "Wishlist.WebApi",

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromHours(1),

                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Autenticação-Wishlist"))
                };
            }
            );

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
                }
            );

            services.AddSwaggerGen(
                c=>c.SwaggerDoc("v1",new Info(){
                    Title = "Documentação Wishlist",
                    Version = "v1"
                })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação Wishlist");
                }
            );

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
