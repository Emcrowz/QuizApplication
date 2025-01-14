interface StartContainerProps {
    children: React.ReactNode;
}

export const StartContainer: React.FC<StartContainerProps> = ({ children }) => {
    return <div className="my-4 flex justify-center">{children}</div>
}