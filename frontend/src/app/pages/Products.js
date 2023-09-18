import React from "react";
import useGetAllProducts from "../../api/products/useGetAllProducts";
import Card from "../../Components/Card";

const Products = () => {
  const { data } = useGetAllProducts();
  return (
    <div>
      <section>
        <h1 className="mb-12 text-center font-sans text-4xl font-bold text-gray-900">
          All Products<span className="text-blue-600"></span>
        </h1>
        <div className="mx-auto grid max-w-screen-xl grid-cols-1 gap-6 p-6 md:grid-cols-2 lg:grid-cols-3">
          {data &&
            data.map((product) => <Card key={product.id} product={product} />)}
        </div>
      </section>
    </div>
  );
};

export default Products;
