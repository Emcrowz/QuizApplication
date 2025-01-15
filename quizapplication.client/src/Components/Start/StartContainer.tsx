interface StartContainerProps {
  children: React.ReactNode;
}

export const StartContainer: React.FC<StartContainerProps> = ({ children }) => {
  return <div className="my-6 flex h-screen justify-center">{children}</div>;
};
