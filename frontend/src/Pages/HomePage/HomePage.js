import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { ToastContainer, toast } from "react-toastify";

const HomePage = () => {

  const count = useSelector(state => state.products.count);
  const dispatch = useDispatch();

  const handleIncrement = () => {
    dispatch({ type: 'INCREMENT' });
  };

  const handleDecrement = () => {
    dispatch({ type: 'DECREMENT' });
  };


  return (
    <div>
      <h1>Count: {count}</h1>
      <button onClick={handleIncrement}>Increment</button>
      <button onClick={handleDecrement}>Decrement</button>
      <button onClick={() => toast("Hello world")}>Toast</button>
    </div>
  );
}

export default HomePage;
