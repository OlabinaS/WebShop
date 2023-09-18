import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { RadioGroup } from "@headlessui/react";
import { useRegister } from "../../api/auth/useRegister";

const roles = [
  {
    name: "Seller",
  },
  {
    name: "Customer",
  },
];

const Register = () => {
  const [userName, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [repeatPassword, setRepeatPassword] = useState("");
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");
  const [dateOfBirth, setDateOfBirth] = useState("");
  const [address, setAddress] = useState("");
  const [role, setRole] = useState(null);
  const [file, setFile] = useState();
  const navigate = useNavigate();

  const register = useRegister();

  const handleSignUp = () => {
    if (
      !userName ||
      !email ||
      !password ||
      !repeatPassword ||
      !name ||
      !lastName ||
      !dateOfBirth ||
      !address ||
      !role
    ) {
      toast.error("All fields are required.");
      return;
    }

    if (password !== repeatPassword) {
      toast.error("Passwords must be the same.");
      return;
    }

    register.mutateAsync({
      userName,
      email,
      password,
      repeatPassword,
      name,
      lastName,
      dateOfBirth,
      address,
      role,
    });
  };

  function handleChangePhoto(e) {
    e.target.files[0] && setFile(URL.createObjectURL(e.target.files[0]));
  }

  return (
    <>
      <div className="m-auto">
        <div className="m-auto flex flex-col max-w-md p-10 rounded-3xl dark:bg-gray-900 dark:text-gray-100">
          <div className="mb-8 text-center">
            <h1 className="my-1 text-3xl font-bold">Sign up</h1>
            <p className="text-lg dark:text-gray-400">Create new account</p>
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
                <div className="flex justify-between mb-2">
                  <label className="text-base">Password</label>
                </div>
                <input
                  type="password"
                  name="password"
                  id="password"
                  placeholder="*****"
                  className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <div>
                <div className="flex justify-between mb-2">
                  <label className="text-base">Repeat Password</label>
                </div>
                <input
                  type="password"
                  name="password2"
                  id="password2"
                  placeholder="*****"
                  className="w-full px-3 py-2 border rounded-lg dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100"
                  onChange={(e) => setRepeatPassword(e.target.value)}
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
              <div>
                <label className="block mb-2 text-base">Role</label>
                <RadioGroup value={role} onChange={setRole}>
                  <div className="space-y-2">
                    {roles.map((plan) => (
                      <RadioGroup.Option
                        key={plan.name}
                        value={plan}
                        className={({ active, checked }) =>
                          `${
                            active
                              ? "ring-2 ring-white ring-opacity-60 ring-offset-2 ring-offset-slate-800"
                              : ""
                          }
                  ${
                    checked
                      ? "bg-gray-400 bg-opacity-75 text-white"
                      : "bg-white"
                  }
                    relative flex cursor-pointer rounded-lg px-5 py-4 shadow-md focus:outline-none`
                        }
                      >
                        {({ active, checked }) => (
                          <>
                            <div className="flex w-full items-center justify-between">
                              <div className="flex items-center">
                                <div className="text-sm">
                                  <RadioGroup.Label
                                    as="p"
                                    className={`font-medium  ${
                                      checked ? "text-white" : "text-gray-900"
                                    }`}
                                  >
                                    {plan.name}
                                  </RadioGroup.Label>
                                </div>
                              </div>
                              {checked && (
                                <div className="shrink-0 text-white">
                                  <CheckIcon className="h-6 w-6" />
                                </div>
                              )}
                            </div>
                          </>
                        )}
                      </RadioGroup.Option>
                    ))}
                  </div>
                </RadioGroup>
              </div>
              <div className="flex flex-col">
                <h2>Add Image:</h2>

                <div class="flex w-full items-center justify-center">
                  <div class="rounded-md border border-gray-100 bg-white p-4 shadow-md">
                    {file ? (
                      <div className="relative w-fit m-3 cursor-pointer">
                        <span
                          onClick={() => setFile(null)}
                          className="absolute top-0 right-0 leading-[0] text-black"
                        >
                          x
                        </span>
                        <img className="w-16" src={file} />
                      </div>
                    ) : (
                      <>
                        <label
                          for="upload"
                          class="flex flex-col items-center gap-2 cursor-pointer"
                        >
                          <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="h-10 w-10 fill-white stroke-indigo-500"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                            stroke-width="2"
                          >
                            <path
                              stroke-linecap="round"
                              stroke-linejoin="round"
                              d="M9 13h6m-3-3v6m5 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"
                            />
                          </svg>
                          <span class="text-gray-600 font-medium">
                            Upload file
                          </span>
                        </label>
                        <input
                          id="upload"
                          type="file"
                          class="hidden"
                          onChange={handleChangePhoto}
                        />
                      </>
                    )}
                  </div>
                </div>
              </div>
            </div>
            <div className="mt-10">
              <div>
                <button
                  onClick={handleSignUp}
                  type="button"
                  className="w-full px-8 py-3 font-semibold rounded-lg dark:bg-blue-400 hover:bg-blue-500 dark:text-gray-900"
                >
                  Sign in
                </button>
              </div>
              <p className="px-6 text-sm text-center mt-4 dark:text-gray-400">
                You have an account?
                <button
                  rel="noopener noreferrer"
                  onClick={() => navigate("/login")}
                  className="hover:underline dark:text-blue-400 ml-1"
                >
                  Sign in
                </button>
                .
              </p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Register;

function CheckIcon(props) {
  return (
    <svg viewBox="0 0 24 24" fill="none" {...props}>
      <circle cx={12} cy={12} r={12} fill="#fff" opacity="0.2" />
      <path
        d="M7 13l3 3 7-7"
        stroke="#fff"
        strokeWidth={1.5}
        strokeLinecap="round"
        strokeLinejoin="round"
      />
    </svg>
  );
}
