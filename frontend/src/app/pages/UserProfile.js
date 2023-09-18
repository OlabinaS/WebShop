import React, { useState } from "react";
import { useQueryClient } from "@tanstack/react-query";
import { toast } from "react-toastify";
import { useChangeProfile } from "../../api/auth/useChangeProfile";

const UserProfile = () => {
  const queryClient = useQueryClient();
  const user = queryClient.getQueryData(["session"]);

  const formattedDate = user.bDay.split(" ");

  return (
    <div className="flex flex-wrap">
      <div className="mr-3 max-w-sm w-full">
        <div className="rounded-lg border bg-white px-4 pt-8 pb-10 shadow-lg">
          <div className="relative mx-auto w-36 rounded-full">
            <img
              className="mx-auto h-auto w-full rounded-full"
              src="https://images.unsplash.com/photo-1500648767791-00dcc994a43e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2.25&w=256&h=256&q=80"
              alt=""
            />
          </div>
          <h1 className="my-1 text-center text-xl font-bold leading-8 text-gray-900">
            {user.name} {user.lastname}
          </h1>
          <h3 className="font-lg text-semibold text-center leading-6 text-gray-600">
            Email: {user.email}
          </h3>
          <ul className="mt-3 divide-y rounded bg-gray-100 py-2 px-3 text-gray-600 shadow-sm hover:text-gray-700 hover:shadow">
            <li className="flex items-center py-3 text-sm">
              <span>Username</span>
              <span className="ml-auto">{user.username}</span>
            </li>
            <li className="flex items-center py-3 text-sm">
              <span>Role</span>
              <span className="ml-auto">
                <span className="rounded-full bg-green-200 py-1 px-2 text-xs font-medium text-green-700">
                  {user.role}
                </span>
              </span>
            </li>
            <li className="flex items-center py-3 text-sm">
              <span>Date of birth</span>
              <span className="ml-auto">{formattedDate[0]}</span>
            </li>
          </ul>
        </div>
      </div>

      <UpdateProfile />
    </div>
  );
};

export default UserProfile;

const UpdateProfile = () => {
  const changeProfile = useChangeProfile();
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUsername] = useState("");
  const [address, setAddress] = useState("");
  const [dateOfBirth, setDateOfBirth] = useState("");
  const [email, setEmail] = useState("");

  const handleUpdateProfile = () => {
    if (!userName && !email && !name && !lastName && !dateOfBirth && !address) {
      toast.error("At least on of the fields must be changed.");
      return;
    }

    changeProfile.mutateAsync({
      userName,
      email,
      name,
      lastName,
      dateOfBirth,
      address,
    });
  };

  return (
    <div className="w-[450px]">
      <div className="m-auto flex flex-col max-w-md p-10 rounded-3xl dark:bg-gray-900 dark:text-gray-100">
        <div className="mb-8 text-center">
          <h1 className="my-1 text-3xl font-bold">Change profile</h1>
        </div>
        <div className="space-y-4 ng-untouched ng-pristine ng-valid">
          <div className="space-y-2">
            <div>
              <label className="block mb-2 text-base">Username</label>
              <input
                name="userName"
                id="userName"
                placeholder="User1"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setUsername(e.target.value)}
              />
            </div>
            <div>
              <label className="block mb-2 text-base">Email address</label>
              <input
                type="email"
                name="email"
                id="email"
                placeholder="name@gmail.com"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div>
              <label className="block mb-2 text-base">Name</label>
              <input
                name="name"
                id="name"
                placeholder="John"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setName(e.target.value)}
              />
            </div>
            <div>
              <label className="block mb-2 text-base">Last Name</label>
              <input
                name="lastName"
                id="lastName"
                placeholder="Doe"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setLastName(e.target.value)}
              />
            </div>
            <div>
              <label className="block mb-2 text-base">Date of birth</label>
              <input
                type="date"
                name="date"
                id="date"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setDateOfBirth(e.target.value)}
              />
            </div>
            <div>
              <label className="block mb-2 text-base">Address</label>
              <input
                name="address"
                id="address"
                placeholder="Main boulevard 1"
                className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                onChange={(e) => setAddress(e.target.value)}
              />
            </div>
          </div>
          <div className="mt-10">
            <div>
              <button
                onClick={handleUpdateProfile}
                type="button"
                className="w-full px-8 py-3 font-semibold rounded-lg dark:bg-blue-400 hover:bg-blue-500 dark:text-gray-900"
              >
                Change profile
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
