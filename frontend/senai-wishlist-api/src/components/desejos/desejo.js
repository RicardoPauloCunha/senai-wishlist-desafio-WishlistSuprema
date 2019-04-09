import React, { Component } from "react";

class Desejo extends Component {
    render() {
        return (
            <div className="desejos-main">
                <div className="desejo">
                    <div className="desejo-header flex">
                        <p className="desejo-header-titulo">{this.props.nome}</p>
                        <p className="desejo-header-data">{this.props.datacriacao}</p>
                    </div>
                    <div className="main-desejo">{this.props.descricao}</div>
                </div>
            </div>
        )
    }
}

export default Desejo;