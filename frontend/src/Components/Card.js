import React from "react";
import { useAddToCart } from "./../api/cart/useAddToCart";
import { useQueryClient } from "@tanstack/react-query";

const Card = ({ product }) => {
  const addToCart = useAddToCart();
  const queryClient = useQueryClient();

  const products = queryClient.getQueryData(["cart"]);

  const isInCart = products && products.find((prod) => prod.id === product.id);

  return (
    <article className="rounded-xl bg-white p-3 shadow-lg hover:shadow-xl">
      <div className="relative flex items-end overflow-hidden rounded-xl">
        <img
          src="https://tecdn.b-cdn.net/img/new/standard/city/041.webp"
          alt="Product"
        />
        <div className="absolute bottom-3 left-3 inline-flex items-center rounded-lg bg-white p-2 shadow-md">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            className="bi bi-cart"
            viewBox="0 0 16 16"
          >
            <path d="M0 1.5A.5.5 0 01.5 1H2a.5.5 0 01.485.379L2.89 3H14.5a.5.5 0 01.491.592l-1.5 8A.5.5 0 0113 12H4a.5.5 0 01-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 01-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 100 4 2 2 0 000-4zm7 0a2 2 0 100 4 2 2 0 000-4zm-7 1a1 1 0 110 2 1 1 0 010-2zm7 0a1 1 0 110 2 1 1 0 010-2z"></path>
          </svg>
          <span className="text-slate-400 ml-1 text-sm">
            {product.quantity}
          </span>
        </div>
      </div>
      <div className="mt-1 p-2">
        <h2 className="text-slate-700">{product.name}</h2>
        <p className="text-slate-400 mt-1 text-sm">{product.description}</p>
        <div className="mt-3 flex items-end justify-between">
          <p>
            <span className="text-lg font-bold text-blue-500">
              ${product.price}
            </span>
            <span className="text-slate-400 text-sm">/product</span>
          </p>
          <div className="group inline-flex rounded-xl bg-blue-100 p-2 hover:bg-blue-200">
            <button
              type="button"
              className="w-full px-3 font-semibold rounded-lg "
              onClick={() => addToCart.mutateAsync(product)}
              disabled={Boolean(isInCart)}
            >
              {Boolean(isInCart) ? "In cart" : "Add to cart"}
            </button>
          </div>
        </div>
      </div>
    </article>
  );
};

export default Card;
