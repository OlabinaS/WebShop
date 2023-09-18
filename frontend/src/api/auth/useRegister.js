import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export function useRegister() {
  const authService = useSendRequest("/users");
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  return useMutation(
    async ({
      userName,
      email,
      password,
      repeatPassword,
      name,
      lastName,
      dateOfBirth,
      address,
      role,
    }) => {
      const formData = new FormData();
      formData.append("Username", userName);
      formData.append("Email", email);
      formData.append("Password", password);
      formData.append("PasswordConfirm", repeatPassword);
      formData.append("Name", name);
      formData.append("Lastname", lastName);
      formData.append("BDay", dateOfBirth);
      formData.append("Address", address);
      formData.append("Role", role.name);

      const { data } = await authService.post("/registration", formData, {
        headers: {
          "Content-Type": "multipart/form-data", // Set the content type to form data
        },
      });
    },
    {
      onSuccess: (data) => {
        toast.success("You have successfully created an account.");
        navigate("/login");
      },
      onError: () => {
        toast.error("Something went wrong.")
      }
    }
  );
}
