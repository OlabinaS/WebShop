import React from "react";
import Link from "./Link";
import { useQueryClient } from "@tanstack/react-query";

const Sidebar = () => {
  const queryClient = useQueryClient();
  const user = queryClient.getQueryData(["session"]);

  const isCustomer = user.role === "Customer";
  const isSeller = user.role === "Seller";
  const isAdmin = user.role === "Admin";

  const handleLogOut = () => {
    localStorage.removeItem("token");
    window.location.reload();
  };

  return (
    <div className="h-fit p-3 pb-7 space-y-2 w-60 dark:bg-blue-500 dark:text-gray-100 rounded-md sticky top-3">
      <div className="flex items-center p-2 space-x-4">
        <img
          src="https://images.unsplash.com/photo-1500648767791-00dcc994a43e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2.25&w=256&h=256&q=80"
          alt=""
          className="w-12 h-12 rounded-full dark:bg-gray-500"
        />
        <div>
          <h2 className="text-lg font-semibold">
            {user.name} {user.lastname}
          </h2>
        </div>
      </div>
      <div>
        <Link to={"/"}> Products </Link>
        <Link to={"/user-profile"}> Profile </Link>
        {isSeller && <Link to={"/add-product"}> Add product </Link>}
        {isAdmin && <Link to={"/admin"}> Admin </Link>}

        <hr className="mt-4" />
        <button onClick={() => handleLogOut()}>Log out</button>
      </div>
    </div>
  );
};

export default Sidebar;
