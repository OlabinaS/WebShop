import React from "react";
import { useNavigate } from "react-router-dom";
import useIsLogged from "../api/auth/useIsLogged";

const withUser = (Component) => {
  return (props) => {
    const navigate = useNavigate();

    const { data, isError, isLoading } = useIsLogged();

    if (isLoading) {
      return <div>Loading...</div>;
    }

    if (isError || data.isLoggedIn === false) {
      navigate("/login");
      return null;
    }

    return <Component {...props} session={data} />;
  };
};

export default withUser;
