import { Participant } from "../../Models/Participant";
import { QuizActionType } from "../../Constants/QuizActionType";
import { QuizAction } from "../../Interfaces/QuizAction";

interface ParticipantLoginProps {
  numberOfQuestions: number;
  dispatch: React.ActionDispatch<[action: QuizAction]>;
}

export const ParticipantLogin: React.FC<ParticipantLoginProps> = ({
  numberOfQuestions,
  dispatch,
}) => {
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const form = e.target as HTMLFormElement;

    const newParticipant: Participant = {
      name: (form.element.namedItem("name") as HTMLInputElement).value,
      email: (form.element.namedItem("email") as HTMLInputElement).value,
      score: 0,
      participationDate: new Date(),
    };

    console.log(newParticipant);

    dispatch({ type: QuizActionType.QuizStart, payload: newParticipant });
  };

  return (
    <div className="my-4 flex justify-center">
      <h1>Hello and welcome to the Quiz!</h1>
      <p>
        There are <strong>{numberOfQuestions}</strong> questions in total
      </p>
      <p>Good luck!</p>
      <form onSubmit={handleSubmit}>
        <input type="text" placeholder="Name" />
        <input type="text" placeholder="Email" />
        <button type="submit">Start</button>
      </form>
    </div>
  );
};
