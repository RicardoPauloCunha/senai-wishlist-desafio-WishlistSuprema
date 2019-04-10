import React, { Component } from 'react';
import './App.css';
// import Menu from "../../components/header/menu";
// import ButtonGeneric from "../../components/inputs/button-generic";
// import Button from "../../components/inputs/button";
// import Rodape from "../../components/rodape/rodape";

import {usuarioToken} from "../../services/auth";
import "../../assents/css/style.css";
import Desejo from '../../components/desejos/Desejo';


class App extends Component {
  constructor() {
    super();
    this.state =
		{
        listaDesejos: [],
        nome: "",
        descricao: ""
      }
	  //isTokenExpired
	  this.PegarNome = this.PegarNome.bind(this);
	  this.PegarDescricao = this.PegarDescricao.bind(this);
	  this.CadastrarDesejo = this.CadastrarDesejo.bind(this);
  }

  componentDidMount() {
    this.BuscarListaDesejos();
  }

  	/* Buscar valores pela API*/
  BuscarListaDesejos() {
    fetch('http://localhost:5000/api/usuario/desejos',{
      method : 'GET',
      headers: {
        'Content-Type': 'application/json',
        Authorization : 'Bearer ' + usuarioToken
      }
    })
      .then(resposta => resposta.json())
      .then(data =>this.setState({ listaDesejos : data.desejo }))
      .catch(erro => console.error(erro))
  }

  /* Buscar valores em campos */
  PegarNome(event) {
		this.setState({ nome: event.target.value });
  }

  PegarDescricao(event) {
    this.setState({ descricao: event.target.value });
  }

	/*Enviar valores para a API*/
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
          Authorization : "Bearer " + usuarioToken
        }
      })
      .then(resposta => resposta)
      .then(this.BuscarListaDesejos())
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
                <button className="button-generic">Sair</button>
              </div>
            </div>
            <div className="menu-titulo">
              <h1>Meus Desejos</h1>
              <div className="linha-vertical"></div>
            </div>
          </div>
        </header>

        <div className="main">
          <div className="btn-main-cadastrar">
            <button className="button" disabled>Cadastrar Desejos</button>
          </div>
          <div>
            <form onSubmit={this.CadastrarDesejo} className="flex form">
              <input type="text" placeholder="Titulo" className="input-form" values = {this.state.nome} onChange={this.PegarNome} />
              <textarea name="" id="" cols="30" rows="6" placeholder="Meu desejo é..."
                className="textarea-form" values = {this.state.descricao} onChange={this.PegarDescricao}></textarea>
              <div className="flex flex-btn-form">
                <button className="button btn-form">Cadastrar</button>
              </div>
            </form>
          </div>
        </div>
        <main className="main">
          <div className="main-header">
            <h2>Lista de Desejos</h2>
            <div className="linha-vertical"></div>
            <div className="desejos-header flex">
              <button className="button margin-rigth" disabled>Recentes</button>
              <button className="button" disabled>Antigos</button>
            </div>
          </div>

          <div className="desejos-container">
          
            <div className="desejos flex">
            {
                this.state.listaDesejos.map(d => {
                  return (
                    <Desejo id={d.id} nome={d.nome} descricao={d.descricao} datacriacao={d.datacriacao.replace("T"," ").split(".")[0]} />
                  );
                })
            }
            </div>
          </div>
        </main>
        <footer>
          <p>Escola Senai de Informática - 2019</p>
        </footer>
      </div>
    );
  }
}

export default App;
