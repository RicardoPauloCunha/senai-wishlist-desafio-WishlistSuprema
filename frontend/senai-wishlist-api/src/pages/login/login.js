import React, { Component } from "react";

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: "",
            senha: ""
        }
    }

PegarEmail(event) {
    this.setState({ email : event.target.value});
}

PegarSenha(event) {
    this.setState({ senha : event.target.value});
}

EfetuarLogin(event) {
    event.preventDefaut();

    fetch('http://192.168.56.1:5000/api/usuario/login', {
        method: "POST",
        body: JSON.stringify({email: this.state.email, senha: this.state.senha}),
        headers: {
            "Content-Type" : "application/json"
        }
    })
    .then(data => {
        if(data.status === 200){
            localStorage.setItem("usuariotoken-wishlist", data.data.tokens)
            this.props.history.push("/desejos");
        } else {
            alert("Email ou Senha Invalida");
        }
    })
    .catch(erro => console.log(erro));
}

    render() {
        return (
            <div>
                <form onSubmit={this.EfetuarLogin.bind(this)}>
                    <input type="text" value={this.state.email} onChange={this.PegarEmail.bind(this)} />
                    <input type="text" value={this.state.senha} onChange={this.PegarSenha.bind(this)} />
                    <button type="submit">entrar</button>
                </form>
            </div>
        );
    }
}

export default Login;