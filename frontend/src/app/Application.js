import React from "react";
import { Route, Routes } from "react-router-dom";
import Authenticated from "./Authenticated";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";
import Products from "./pages/Products";
import UserProfile from "./pages/UserProfile";
import AddProduct from "./pages/seller/AddProduct";
import Verification from "./pages/admin/Verification";

const Application = () => {
  return (
    <Routes>
      {/* Authorizes routes */}
      <Route path="/" element={<Authenticated />}>
        <Route element={<Dashboard />}>
          <Route index element={<Products />} />
          <Route exact path="/user-profile" element={<UserProfile />} />
          <Route exact path="/add-product" element={<AddProduct />} />
          <Route exact path="/admin" element={<Verification />} />
        </Route>
      </Route>

      {/* Unauthorized routes */}
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Application;
