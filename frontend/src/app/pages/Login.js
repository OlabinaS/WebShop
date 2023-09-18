import React, { useState } from "react";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { useLogin } from "../../api/auth/useLogin";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const login = useLogin();

  const handleLogin = () => {
    if (!email || !password) {
      toast.error("Email and password are required");
      return;
    }

    login.mutateAsync({email, password});
  };

  return (
    <>
      <div className="m-auto">
        <div className="m-auto flex flex-col max-w-md p-10 rounded-3xl dark:bg-gray-900 dark:text-gray-100">
          <div className="mb-8 text-center">
            <h1 className="my-1 text-3xl font-bold">Sign in</h1>
            <p className="text-lg dark:text-gray-400">
              Sign in to access your account
            </p>
          </div>
          <div className="space-y-4 ng-untouched ng-pristine ng-valid">
            <div className="space-y-4">
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
            </div>
            <div className="mt-10">
              <div>
                <button
                  onClick={handleLogin}
                  type="button"
                  className="w-full px-8 py-3 font-semibold rounded-lg dark:bg-blue-400 hover:bg-blue-500 dark:text-gray-900"
                >
                  Sign in
                </button>
              </div>
              <p className="px-6 text-sm text-center mt-4 dark:text-gray-400">
                Don't have an account yet?
                <button
                  rel="noopener noreferrer"
                  onClick={() => navigate("/register")}
                  className="hover:underline dark:text-blue-400 ml-1"
                >
                  Sign up
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

export default Login;
