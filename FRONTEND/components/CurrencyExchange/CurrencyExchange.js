import React, { useState , useEffect} from 'react';

export default function CurrencyExchange(props) {
        
    const [montoCalculado, setMontoCalculado] = useState(null);

    useEffect(() => {
        (async () => {
            const { MoneySource, MoneyDestination, Amount } = props.calculeCurrency;

                if (MoneySource > MoneyDestination){
                    const monto = Amount / MoneySource;
                    const total = parseFloat(monto).toFixed(2);
                    setMontoCalculado(total);
                }else{
                    const monto = Amount * MoneyDestination;
                    const total = parseFloat(monto).toFixed(2);
                    setMontoCalculado(total);
                }
                
        })();
    }, []);

    return (
        <>
            {
                montoCalculado && (
                    <label> {montoCalculado} </label>
                )
            }
        </>
    )
}
