import "./App.css";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ReactQueryProvider from "./ReactQueryProvider";
import Application from "./app/Application";
import { BrowserRouter } from "react-router-dom";
import { createPortal } from "react-dom";

function App() {
  return (
    <BrowserRouter>
      <ReactQueryProvider>
        <Application />
      </ReactQueryProvider>
      {createPortal(
        <ToastContainer
          position="top-right"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          // rtl={false}
          pauseOnFocusLoss
          pauseOnHover
          theme="dark"
        />,
        document.body
      )}
    </BrowserRouter>
  );
}

export default App;
