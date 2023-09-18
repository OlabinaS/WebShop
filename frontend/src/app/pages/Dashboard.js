import React from "react";
import { Outlet } from "react-router-dom";
import Sidebar from "../../Components/Sidebar";

const Dashboard = () => {
  return (
    <div className="flex flex-1 p-3">
      <Sidebar />

      <div className="pl-3 w-full">
        <Outlet />
      </div>
    </div>
  );
};

export default Dashboard;
