import './App.css';
import {useEffect, useState} from "react";
import io from "socket.io-client";

const socket = io.connect("http://localhost:8000");

function App() {
  const [items, setItems] = useState([]);

  useEffect(() => {
    socket.on("order_received", (data) => {
      setItems((prevItems) =>[...prevItems, data]);
    })
    console.log(items);
  }, [socket])

  return (
    <div className="outer-container">
      <div className="inner-container">
        <h1>
          Order List 
        </h1>
        <div className='order-detail'>
          {(items.length === 0)?<p>empty!</p>:(
            items.map((item, orderNumber) => (
              <div key={orderNumber} className='order-content'>
                <div>Table: {orderNumber}</div>
                {item.map((food, index) => {
                  return (
                  <>
                      <div className="order-info" key={index}>{food.amount} {food.name}</div>
                  </>
                  )
                })}
              </div>
            ))
          )
          }
        </div>
      </div>
    </div>
  );
}

export default App;
