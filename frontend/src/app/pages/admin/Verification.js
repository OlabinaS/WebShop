import React from "react";
import useVerification from "../../../api/admin/useVerification";
import moment from "moment";

const Verification = () => {
  const { data } = useVerification();

  return (
    <div className="border rounded-md">
      <div className="container p-2 mx-auto sm:p-4 text-gray-800">
        <h2 className="mb-4 text-2xl font-semibold leadi">Invoices</h2>
        <div className="overflow-x-auto">
          <table className="min-w-full text-xs">
            <colgroup>
              <col />
              <col />
              <col />
              <col />
              <col />
              <col />
              <col className="w-24" />
            </colgroup>
            <thead className="bg-gray-300">
              <tr className="text-left">
                <th className="p-3">Invoice #</th>
                <th className="p-3">Client</th>
                <th className="p-3">Username</th>
                <th className="p-3">Email</th>
                <th className="p-3">Date of birth</th>
                <th className="p-3">Status</th>
                <th className="p-3 text-right">Action</th>
              </tr>
            </thead>
            <tbody>
              {data &&
                data.map((seller) => (
                  <tr
                    key={seller.username}
                    className="border-b border-opacity-20 border-gray-300 bg-gray-50"
                  >
                    <td className="p-3">
                      <p>{seller.id}</p>
                    </td>
                    <td className="p-3">
                      <p>
                        {seller.firstname} {seller.lastname}
                      </p>
                    </td>
                    <td className="p-3">
                      <p>{seller.username}</p>
                    </td>
                    <td className="p-3">
                      <p>{seller.email}</p>
                    </td>
                    <td className="p-3">
                      <p>{moment(seller.birthdate).format("DD.MM.YYYY.")}</p>
                    </td>
                    <td className="p-3">{getBadge(seller.verification)}</td>
                    <td className="p-3 text-right">
                      {seller.verification == 0 && renderVerificationOption()}
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default Verification;

const getBadge = (status) => {
  if (status == 1) {
    return (
      <span className="rounded-full bg-green-200 py-1 px-2 text-xs font-medium text-green-700">
        Approved
      </span>
    );
  }

  if (status == 2) {
    return (
      <span className="rounded-full bg-red-200 py-1 px-2 text-xs font-medium text-red-700">
        Denied
      </span>
    );
  }

  return (
    <span className="rounded-full bg-violet-200 py-1 px-2 text-xs font-medium text-violet-700">
      Pending
    </span>
  );
};

const renderVerificationOption = () => {
  return (
    <div className="flex">
      <button className="px-3 py-1 font-semibold border rounded-full bg-green-400 text-gray-100">
        Approve
      </button>
      <button className="px-3 py-1 font-semibold border rounded-full border-red-400 text-gray-800 ml-1">
        Reject
      </button>
    </div>
  );
};
