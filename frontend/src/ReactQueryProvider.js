import React, { ReactNode, Ref, useMemo, useRef } from "react";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

const cacheTime = 1000 * 60 * 60 * 8; // 8 hours

const ReactQueryProvider = ({
  children,
}) => {
  const queryClient = useMemo(
    () =>
      new QueryClient({
        defaultOptions: {
          queries: {
            cacheTime,
            retry: false,
            refetchOnWindowFocus: false,
          },
          mutations: {
            retry: false,
          },
        },
      }),
    []
  );
  return (
    <QueryClientProvider client={queryClient}>
      {children}
      <Devtools />
    </QueryClientProvider>
  );
};

export default ReactQueryProvider;

const Devtools = () => {
  const containerRef = useRef();

  return (
    <div
      ref={containerRef}
      className="fixed l-0 b-0 z-[9001]"
    >
      <ReactQueryDevtools />
    </div>
  );
};