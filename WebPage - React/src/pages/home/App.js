import React, { Component } from 'react';
import './App.css';
import { withRouter } from 'react-router-dom';
import Desejo from '../../components/desejos/desejo.js';
import Footer from "../../components/rodape/rodape.js";


class App extends Component {
  constructor() {
    super();
    this.state =
    {
      listaDesejos: [],
      nome: "",
      descricao: ""
    }
    this.PegarNome = this.PegarNome.bind(this);
    this.PegarDescricao = this.PegarDescricao.bind(this);
    this.CadastrarDesejo = this.CadastrarDesejo.bind(this);
  }

  componentDidMount() {
    this.BuscarListaDesejos();
  }

  BuscarListaDesejos() {
    fetch('http://localhost:5000/api/usuario/desejos', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + localStorage.getItem("usuariotoken-wishlist")
      }
    })
      .then(resposta => resposta.json())
      .then(data => this.setState({ listaDesejos: data.desejo }))
      .catch(erro => console.error(erro))
  }

  PegarNome(event) {
    this.setState({ nome: event.target.value });
  }

  PegarDescricao(event) {
    this.setState({ descricao: event.target.value });
  }

  CadastrarDesejo(event) {
    event.preventDefault();

    fetch('http://localhost:5000/api/desejo/cadastro',
      {
        method: 'POST',
        body: JSON.stringify({
          nome: this.state.nome,
          descricao: this.state.descricao
        }),
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("usuariotoken-wishlist")
        }
      })
      .then(resposta => resposta)
      .then(() => {
        this.BuscarListaDesejos();
        alert("Desejo cadastrado com sucesso");
      })
      .catch(erro => console.log(erro))
  }

  render() {
    return (
      <div>
        <header>
          <div className="menu">
            <div className="menu-nav flex">
              <div className="menu-nav-login">

              </div>
              <div className="menu-nav-logo flex">
                <div className="menu-nav-logo-circulo"></div>
              </div>
              <div className="menu-nav-login">
                <button className="button-generic btn-click" onClick={(props) => {
                  localStorage.removeItem("usuariotoken-wishlist");
                  this.props.history.push("./login");
                }
                }>Sair</button>
              </div>
            </div>
            <div className="menu-titulo">
              <h1>Meus Desejos</h1>
              <div className="linha-vertical1"></div>
            </div>
          </div>
        </header>

        <div className="main App-text-align">
          <h2>Adicionar Desejo</h2>
          <div className="linha-vertical"></div>
          <div>
            <form onSubmit={this.CadastrarDesejo} className="flex form">
              <input type="text" placeholder="Titulo" className="input-form" values={this.state.nome} onChange={this.PegarNome} required />
              <textarea name="" id="" cols="30" rows="6" placeholder="Meu desejo é..." required
                className="textarea-form" values={this.state.descricao} onChange={this.PegarDescricao}></textarea>
              <button className="button btn-form btn-click">Cadastrar</button>
            </form>
          </div>
        </div>
        <main className="main">
          <div className="main-header">
            <h2>Lista de Desejos</h2>
            <div className="linha-vertical"></div>
          </div>

          <div className="desejos-container">
            <div className="desejos flex">
              {this.state.listaDesejos.map(d => {
                return (
                  <Desejo key={d.desejoid} nome={d.nome} descricao={d.descricao} datacriacao={d.datacricao.replace("T", " ").split(".")[0]} />
                );
              })}
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default withRouter(App);
