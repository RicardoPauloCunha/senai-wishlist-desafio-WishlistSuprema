import React, { Component } from "react";

class Button extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <button class="button">
                {this.props.textbutton}
            </button>
        );
    }
}

export default Button;