import React, { Component } from "react";

class ButtonGenereic extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <button class="button-generic">
                {this.props.textbutton}
            </button>
        );
    }
}

export default ButtonGenereic;