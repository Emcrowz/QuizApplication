interface QuizContainerProps {
  children: React.ReactNode;
}

export const QuizContainer: React.FC<QuizContainerProps> = ({ children }) => {
  return <div className="my-4 flex justify-center">{children}</div>;
};
