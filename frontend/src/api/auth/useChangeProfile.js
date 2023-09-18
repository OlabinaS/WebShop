import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";
import useGetNewToken from "./useGetNewToken";

export function useChangeProfile() {
  const authService = useSendRequest("/users");
  const queryClient = useQueryClient();

  return useMutation(
    async ({ userName, email, name, lastName, dateOfBirth, address }) => {
      let changedData = {};

      if (userName) {
        changedData = { ...changedData, username: userName };
      }
      if (email) {
        changedData = { ...changedData, email: email };
      }
      if (name) {
        changedData = { ...changedData, name: name };
      }
      if (lastName) {
        changedData = { ...changedData, lastname: lastName };
      }
      if (dateOfBirth) {
        changedData = { ...changedData, birthdate: dateOfBirth };
      }
      if (address) {
        changedData = { ...changedData, address: address };
      }

      const { data } = await authService.put("/update-user", changedData);

      return data;
    },
    {
      onSuccess: () => {
      },
    }
  );
}
