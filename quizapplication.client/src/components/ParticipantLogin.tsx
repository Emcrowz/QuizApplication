import { QuizActionType } from "../constants/QuizActionType";
import { ParticipantModel } from "../types/ParticipantModel";

interface ParticipantLoginProps {
    numberOfQuestions: number;
    dispatch: any;
}

export const ParticipantLogin: React.FC<ParticipantLoginProps> = ({ numberOfQuestions, dispatch }) => {
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const newParticipant: ParticipantModel = {
            name: (e.target as any).elements[0].value,
            email: (e.target as any).elements[1].value,
            score: 0,
            participationDate: new Date()
        };

        console.log(newParticipant);

        dispatch({ type: QuizActionType.QuizStart, payload: newParticipant });
    }

    return (
        <div className="my-4 flex justify-center">
            <h1>Hello and welcome to the Quiz!</h1>
            <p>There are <strong>{numberOfQuestions}</strong> questions in total</p>
            <p>Good luck!</p>
            <form onSubmit={handleSubmit}>
                <input type="text" placeholder="Name" />
                <input type="text" placeholder="Email" /> 
                <button type="submit">Start</button>
            </form>
        </div>
    );
}