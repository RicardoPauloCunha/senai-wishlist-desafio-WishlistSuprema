import React, {Component} from "react";
import axios from "axios";

class Cadastro extends Component {
    constructor(props){
        super(props);
        this.state = {
            nome : "", 
            email : "",
            senha : "",
            mensagemerro: ""
        }
    }

    pegarNome(event) {
        this.setState({nome : event.target.value})
    }
    
    PegarEmail(event) {
        this.setState({ email: event.target.value });
    }

    PegarSenha(event) {
        this.setState({ senha: event.target.value });
    }

    Cadastrar(event) {
        event.preventDefault();

        axios.post('http://localhost:5000/api/usuario/cadastro', {
            nome: this.state.nome,
            email: this.state.email,
            senha: this.state.senha,
        })
            .then(data => {
                if (data.status === 200) {
                    alert("Usuario cadastrado com sucesso");
                    this.props.history.push("/login");
                }
            })
            .catch(erro => alert(erro));
    }


    render() {
        return (
            <div className="bk-img">
        <div className="main-container">
            <header className="menu-nav-login">
            </header>

            <main>
                <div className="menu-titulo">
                    <h1>Cadastrar Usuário</h1>
                </div>

                <div>
                    <form onSubmit={this.Cadastrar.bind(this)} className="flex form-login">
                        <input className="input-form-login" type="text" placeholder="Nome" required value={this.state.nome} onChange={this.pegarNome.bind(this)}/>
                        <input className="input-form-login" type="email" placeholder="Email" required value={this.state.email} onChange={this.PegarEmail.bind(this)}/>
                        <input className="input-form-login" type="password" placeholder="Senha" minLength="8" value={this.state.senha} onChange={this.PegarSenha.bind(this)}/>
                        <button type="submit" className="button-generic btn-form-login btn-click">Cadastrar</button>
                    </form>
                </div>

            </main>

            <footer className="footer-login">
                <div className="linha-vertical1"></div>
                <div>
                    <p className="p-footer-login">Ja possuir uma Conta? <a href="./login">Entrar</a></p>
                </div>
                <div className="footer-fim"></div>
            </footer>
        </div>
    </div>
        )
    }
}

export default Cadastro;
