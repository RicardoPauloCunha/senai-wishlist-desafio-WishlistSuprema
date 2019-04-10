import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect} from "react-router-dom";
import "./assents/css/style.css";
import NaoEncontrada from "./pages/naoEncontrada/naoEncontrada";

import App from './pages/home/App';
import Login from "./pages/login/login";

import * as serviceWorker from './serviceWorker';
import {usuarioToken} from "./services/auth";

const Permissao = ({component : Component}, {...rest}) => (
    <Route
      {...rest}
      render = {props => usuarioToken != null?
        <Component {...props} /> :
        <Redirect to={{pathname:"/login"}} />
      }
    />
  );

const Routing = (
    <Router>
        <div>
            <Switch>
                <Permissao exact path="/" component={App} />
                <Route path="/login" component={Login} />
                <Route component={NaoEncontrada} />
            </Switch>
        </div>
    </Router>
)
    
ReactDOM.render(Routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
