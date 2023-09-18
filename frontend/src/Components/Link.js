import clsx from "clsx";
import { NavLink } from "react-router-dom";

const Link = ({ to, children, className }) => (
  <NavLink
    to={to}
    className={({ isActive }) =>
      clsx(
        "flex items-center p-[5px] py-2 mb-[4px] text-sm rounded-md",
        {
          "opacity-100 shadow-inner active bg-white/50 text-black font-bold":
            isActive,
          "hover:bg-white/70 text-black font-medium": !isActive,
        },
        className
      )
    }
  >
    {({ isActive }) => <>{children}</>}
  </NavLink>
);

export default Link;
