import React from 'react'
import Header from '../../components/Header/Header';
import Footer from '../../components/Footer/Footer';
import CurrencyExchangeSearch from '../../components/CurrencyExchangeSearch';

export default function PrincipalLayout(props) {
    const { pagina } = props;
    
    return (
        <div className="principal-layout">
            <Header origen="principal"/>

            <div className="contenido">

                <div className="content">
                  
                  <OpcionMenu pagina={pagina}/>
                    
                </div>
            </div>
            
            <Footer/>
        </div>
    )
}

function OpcionMenu(props) {
    const { pagina } = props;
    switch (pagina) {
      case 'search':
        return <CurrencyExchangeSearch/>;
      default:
        return <CurrencyExchangeSearch/>;
    }
}