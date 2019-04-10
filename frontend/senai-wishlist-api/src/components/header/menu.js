import React, { Component } from "react";

class Menu extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <header>
                <div class="menu">
                    <div class="menu-nav flex">
                        <div class="menu-nav-login">

                        </div>
                        <div class="menu-nav-logo flex">
                            <div class="menu-nav-logo-circulo"></div>
                        </div>
                        <div class="menu-nav-login">
                            <button class="button-generic">Sair</button>
                        </div>
                    </div>
                    <div class="menu-titulo">
                        <h1>{this.props.titulo}</h1>
                        <div class="linha-vertical"></div>
                    </div>
                </div>
            </header>
        );
    }
}

export default Menu;