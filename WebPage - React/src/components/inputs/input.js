import React, { Component } from "react";

class Input extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <input
                id="input-cadastro-login"
                type={this.props.tipo}
                className={this.props.className}
                placeholder={this.props.placeholder}
            />
        );
    }
}

export default Input;