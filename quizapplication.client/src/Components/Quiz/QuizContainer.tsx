interface QuizContainerProps {
  children: React.ReactNode;
}

export const QuizContainer: React.FC<QuizContainerProps> = ({ children }) => {
  return <div className="flex justify-center h-screen my-6">{children}</div>;
};
