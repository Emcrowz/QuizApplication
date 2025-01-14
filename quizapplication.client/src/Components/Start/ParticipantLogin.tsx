import { Participant } from "../../Models/Participant";
import { QuizActionType } from "../../Constants/QuizActionType";
import { QuizAction } from "../../Interfaces/QuizAction";
import { useNavigate } from "react-router-dom";

interface ParticipantLoginProps {
  numberOfQuestions: number;
  dispatch: React.ActionDispatch<[action: QuizAction]>;
}

export const ParticipantLogin: React.FC<ParticipantLoginProps> = ({
  numberOfQuestions,
  dispatch,
}) => {
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const newParticipant: Participant = {
      name: (e.target as any).elements[0].value,
      email: (e.target as any).elements[1].value,
      score: 0,
      participationDate: new Date(),
    };

    dispatch({ type: QuizActionType.QuizStart, payload: newParticipant });
  };

    const handleNavigateToLeaderboard = () => {
        navigate("/leaderboard");
    };

  return (
      <>
        <div className="">
            <h1 className="text-5xl">Hello and welcome to the Quiz!</h1>
            <h2 className="my-4 text-3xl">
                There are <strong>{numberOfQuestions}</strong> questions in total
            </h2>
            <p className="my-8 text-2xl italic">Good luck!</p>
            <p className="mb-4 text-xl">Type in your name and email and begin playing!</p>
        </div>
        <form className="" onSubmit={handleSubmit}>
            <div className="">
                <input className="border-2 w-max rounded-xl p-4" type="text" placeholder="Name" />
                <input className="border-2 w-max rounded-xl p-4" type="text" placeholder="Email" />
            </div>

            <div className="">
                <button className="bg-green-500/65 rounded-xl p-4 hover:bg-green-400/85" type="submit">Start</button>
                <button className="bg-amber-500/65 rounded-xl p-4 hover:bg-amber-400/85" type="button" onClick={handleNavigateToLeaderboard}>
                    Check the Leaderboard
                </button>
            </div>
        </form>

    </>
  );
};
