import React, { Component } from "react";
import axios from "axios";

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: "",
            senha: ""
        }
    }

    PegarEmail(event) {
        this.setState({ email: event.target.value });
    }

    PegarSenha(event) {
        this.setState({ senha: event.target.value });
    }

    EfetuarLogin(event) {
        event.preventDefault();
        
        axios.post('http://localhost:5000/api/usuario/login', {
            email: this.state.email,
            senha: this.state.senha,
        })
        .then(data => {
            if (data.status === 200) {
                localStorage.setItem("usuariotoken-wishlist", data.data.token)
                this.props.history.push("/");
            }else{
                console.log(data);
            }
        })
        .catch(erro => alert("Email ou senha invalidos"));
    }


    render() {
        return (
            <div className="bk-img">
                <main className="main-container">
                    <header className="menu-nav-login flex">
                        <div className="menu-nav-logo-circulo"></div>
                    </header>

                    <main>
                        <div className="menu-titulo">
                            <h1>Login</h1>
                        </div>

                        <div>
                            <form onSubmit={this.EfetuarLogin.bind(this)} className="flex form-login">
                                <input className="input-form-login" type="email" placeholder = "Email" value={this.state.email} onChange={this.PegarEmail.bind(this)} required />
                                <input className="input-form-login" type="password" placeholder = "Senha" value={this.state.senha} onChange={this.PegarSenha.bind(this)} required />
                                <button className="btn-form-login button-generic btn-click" type="submit">Entrar</button>
                            </form>
                        </div>

                    </main>

                    <footer className="footer-login">
                        <div className="linha-vertical1"></div>
                        <div>
                            <p className="p-footer-login">Não possui uma Conta? <a href="./cadastro">Cadastre-se</a></p>
                        </div>
                        <div className="footer-fim flex"></div>
                    </footer>
                </main>
            </div>
        );
    }
}

export default Login;