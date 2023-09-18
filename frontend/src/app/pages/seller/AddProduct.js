import React, { useState } from "react";
import { useAddProduct } from "../../../api/products/useAddProduct";
import { toast } from "react-toastify";

const AddProduct = () => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState(0);
  const [quantity, setQuantity] = useState(0);
  const [description, setDescription] = useState("");

  const addProduct = useAddProduct();

  const handleAddProduct = () => {
    if (!name || !price || !quantity || !description) {
      toast.error("All fields are required.");
      return;
    }

    addProduct.mutateAsync({ name, price, quantity, description });
  };

  return (
    <div>
      <div className="container flex flex-col mx-auto space-y-12">
        <fieldset className="flex flex-col gap-6 p-6 rounded-md shadow-sm border drop-shadow-lg ">
          <div className="space-y-2 col-span-full lg:col-span-1">
            <h1 className="font-bold text-xl text-center">Add new product</h1>
          </div>
          <div className="grid grid-cols-6 gap-4 col-span-full lg:col-span-3">
            <div className="col-span-full sm:col-span-2">
              <label for="Product" className="text-sm">
                Product name
              </label>
              <input
                id="product"
                type="text"
                placeholder="Product name"
                className="w-full rounded-md h-10 px-3 dark:border-gray-700 dark:text-gray-900"
                onChange={(e) => setName(e.target.value)}
              />
            </div>
            <div className="col-span-full sm:col-span-2">
              <label for="price" className="text-sm">
                Price
              </label>
              <input
                id="price"
                type="number"
                min={0}
                placeholder="Price"
                className="w-full rounded-md h-10 px-3 dark:border-gray-700 dark:text-gray-900"
                onChange={(e) => setPrice(e.target.value)}
              />
            </div>
            <div className="col-span-full sm:col-span-2">
              <label for="quantity" className="text-sm">
                Quantity
              </label>
              <input
                id="quantity"
                type="number"
                min={0}
                placeholder="Quantity"
                className="w-full rounded-md h-10 px-3 dark:border-gray-700 dark:text-gray-900"
                onChange={(e) => setQuantity(e.target.value)}
              />
            </div>
            <div className="col-span-full">
              <label for="description" className="text-sm">
                Description
              </label>
              <textarea
                id="description"
                placeholder="Description"
                className="w-full rounded-md p-3 dark:border-gray-700 dark:text-gray-900"
                rows={5}
                onChange={(e) => setDescription(e.target.value)}
              ></textarea>
            </div>
          </div>
        </fieldset>
      </div>

      <button
        onClick={handleAddProduct}
        type="button"
        className="mt-3 px-8 py-3 font-semibold rounded-lg dark:bg-yellow-400 hover:bg-yellow-500 dark:text-gray-900"
      >
        Publish product
      </button>
    </div>
  );
};

export default AddProduct;
