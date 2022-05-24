import React, { Component } from 'react';
//import {NorthwindController} from '../../../Controllers';


export class Productos extends Component{

    static displayName = Productos.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
      }

      render(){
        return (
            <div>
              <h1 id="tabelLabel">Catalogo de productos</h1>
            </div>
          );
    
    }
} 