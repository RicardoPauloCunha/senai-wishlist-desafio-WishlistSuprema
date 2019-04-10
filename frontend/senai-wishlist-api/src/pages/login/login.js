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
    this.setState({ email : event.target.value});
}

PegarSenha(event) {
    this.setState({ senha : event.target.value});
}

EfetuarLogin(event) {
    event.preventDefault();

    axios.post('http://localhost:5000/api/usuario/login', {
        email : this.state.email,
        senha : this.state.senha,
    })
    .then(data => {
        if(data.status === 200){
            localStorage.setItem("usuariotoken-wishlist", data.data.token)
            this.props.history.push("/");
        }
    })
    .catch(erro => alert("Email ou senha invalidos"));
}

    render() {
        return (
            <div>
                <form onSubmit={this.EfetuarLogin.bind(this)}>
                    <input type="email" value={this.state.email} onChange={this.PegarEmail.bind(this)} required/>
                    <input type="password" value={this.state.senha} onChange={this.PegarSenha.bind(this)} required />
                    <button type="submit">Entrar</button>
                </form>
            </div>
        );
    }
}

export default Login;