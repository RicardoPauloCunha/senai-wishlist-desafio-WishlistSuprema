import React, { Component } from "react";

class Desejo extends Component {
    render() {
        return (
            <div className="desejos-main" key={this.props.id}>
                <div className="desejo">
                    <div className="desejo-header flex">
                        <p className="desejo-header-titulo">{this.props.nome}</p>
                        <p className="desejo-header-data">{this.props.datacriacao}</p>
                    </div>
                    <p className="main-desejo">{this.props.descricao}</p>
                </div>
            </div>
        )
    }
}

export default Desejo;