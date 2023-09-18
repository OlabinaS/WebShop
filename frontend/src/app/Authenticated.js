import React from "react";
import { Outlet } from "react-router-dom";
import withUser from "../Auth/withUser";

const Authenticated = () => {
  return (
    <>
      <Outlet />
    </>
  );
};

export default withUser(Authenticated);
