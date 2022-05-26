import React, { Component } from 'react';
//import {NorthwindController} from '../../../Controllers';


export class Productos extends Component{

    static displayName = Productos.name;

    constructor(props) {
        super(props);
        this.state = { productos: [], loading: true };

        
      }

      componentDidMount(){
        this.traerProductos();
      }

      renderProductos(productos) {
        return (
          <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
              <tr>
                <th>ProdctId</th>
                <th>Nombre Producto</th>
                <th>QuantityPerUnit</th>
                <th>UnitPrice</th>
              </tr>
            </thead>
            <tbody>
              {productos.map(product =>
                <tr key={product.ProductId}>
                  <td>{product.productId}</td>
                  <td>{product.productName}</td>
                  <td>{product.QuantityPerUnit}</td>
                  <td>{product.UnitPrice}</td>
                </tr>
              )}  
            </tbody>
          </table>
        );
      }

      render(){
        let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderProductos(this.state.productos);
        return (
            <div>
              <h1 id="tabelLabel">Catalogo de productos</h1>
              {contents}
            </div>

          );
    
      }

      async traerProductos() {
        const response = await fetch('northwind/productos');
        const data = await response.json();
    
        console.log(data);    
    
        this.setState({ productos: data, loading: false });
      }
} 