import React, { useState, useEffect }  from 'react'
import { getToken, getMoneys, getCurrencyExchange } from '../../api/currencys';
import { map } from 'lodash';
import Funciones from '../../utils/funciones';
import CurrencyExchange from '../CurrencyExchange';

export default function CurrencyExchangeSearch() {


    const [cargar, setCargar] = useState(false);
    const [showCalcule, setShowCalcule] = useState(false);
    const [errorTipoCambio, setErrorTipoCambio] = useState("");

    const [sourceMoney, setSourceMoney] = useState(null);
    const [token, setToken] = useState(null)
    const [formState, setFormState] = useState({
        Type    : 1,
        CurrencySource : '',
        CurrencyDestination : '',
        MoneySource: 0,
        MoneyDestination: 0,
        Created    : Funciones.FechaActual(),
        Amount : 0,
    })
    
    const [calculeCurrency, setCalculeCurrency] = useState({
        CurrencySource : '',
        CurrencyDestination : '',
        MoneySource: 0,
        MoneyDestination: 0,
        Amount: 0,
        Calcule: false,
    });
    
    const {Type, CurrencySource, CurrencyDestination,MoneySource, MoneyDestination, Created, Amount} = formState;

    const handleInputChange = ({ target }) => {
        setFormState({
            ...formState,
            [target.name]: target.value
        })
    }

    async function search(){
        const data = {
            Type :  2,
            CurrencySource : CurrencySource,
            CurrencyDestination : CurrencyDestination,
            Created : Funciones.FechaActual(),
        }
        const token = await getToken();
        if (token > ''){
            const listCurrencyExchange = await getCurrencyExchange(data,token);
            
            if(listCurrencyExchange){
                setShowCalcule(false);
                setCalculeCurrency({
                    CurrencySource : listCurrencyExchange.CurrencySource,
                    CurrencyDestination : listCurrencyExchange.CurrencyDestination,
                    MoneySource: listCurrencyExchange.MoneySource,
                    MoneyDestination: listCurrencyExchange.MoneyDestination,
                    Amount: Amount
                });
                setShowCalcule(true);
                setErrorTipoCambio("");
            }else{
                setShowCalcule(false);
                setErrorTipoCambio("No existe registrado el tipo de cambio de moneda"); 
            }
        }
    }

    useEffect(() => {
        (async () => {
            const tokenGen = await getToken();
            console.log(tokenGen);
            if(tokenGen != null ){
                setToken(tokenGen);
                const data = {
                    Type :  3,
                    CurrencySource : "",
                    CurrencyDestination : "",
                    Created : Funciones.FechaActual(),
                }
                const listMoney = await getMoneys(data,token);
                setSourceMoney(listMoney || []);
                setCargar(true);
            }
        })();
    }, [!cargar]);

    if (!sourceMoney) return null;

    return (
        <>
                <p className="titulo">CAMBIO DE MONEDA</p>
                {
                    !cargar && (
                        <img className="loading" 
                             src="loading.gif" 
                             alt="cargando..."/>
                    )
                }
                  <div className="filtros">
                      <label htmlFor="CurrencySource"> Moneda Origen : </label>
                      <select name="CurrencySource" onChange={ handleInputChange }> 
                        <option value="NA">Seleccione</option>
                        {
                        sourceMoney && (
                            map(sourceMoney, item => {
                            return <option key={item.Currency}>{item.Currency}</option>
                            })
                        )
                        }
                      </select>
                  </div>
                  <div className="filtros">
                  <label htmlFor="CurrencyDestination"> Moneda Destino : </label>
                  <select name="CurrencyDestination" onChange={ handleInputChange }> 
                        <option value="NA">Seleccione</option>
                        {
                        sourceMoney && (
                            map(sourceMoney, item => {
                            return <option key={item.Currency}>{item.Currency}</option>
                            })
                        )
                        }
                      </select>
                  </div>
                  <div className="filtros">
                  <label htmlFor="Amount"> Monto : </label>
                    <input type="number" name="Amount" value = {Amount}  onChange={ handleInputChange }/>
                  </div>
                  <div className="busqueda">
                    <button className="btn-buscar"
                            onClick={search}>
                        Submit
                    </button>
                  </div>
                  {
                      errorTipoCambio.length > 0 && (
                        <label> {errorTipoCambio} </label>

                      )
                  }
                  <div className="filtros">
                    {
                        showCalcule && (
                            <CurrencyExchange calculeCurrency={calculeCurrency}/>
                        )
                    }
                  </div>

        </>
    )
}
