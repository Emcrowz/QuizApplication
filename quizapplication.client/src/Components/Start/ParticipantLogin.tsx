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
      participationDate: new Date(),
      finalAnswers: [],
      score: 0,
    };

    dispatch({ type: QuizActionType.QuizStart, payload: newParticipant });
  };

  const handleNavigateToLeaderboard = () => {
    navigate("/leaderboard");
  };

  return (
    <div className="content-center">
      <div className="">
        <h1 className="text-center text-5xl">Hello and welcome to the Quiz!</h1>
        <h2 className="text-center my-4 text-3xl">
          There are <strong>{numberOfQuestions}</strong> questions in total
        </h2>
        <p className="my-8 text-center text-2xl italic">Good luck!</p>
        <p className="mb-4 text-center text-xl">
          Type in your name and email and begin playing!
        </p>
      </div>
      <form className="" onSubmit={handleSubmit}>
        <div className="grid grid-cols-2 gap-4 justify-center">
          <input
            className="border-2 text-center rounded-xl p-4"
            type="text"
            placeholder="Name"
          />
          <input
            className="border-2 text-center rounded-xl p-4"
            type="text"
            placeholder="Email"
          />
        </div>

        <div className="grid mt-4">
          <button
            className="bg-green-500/65 rounded-xl p-4 hover:bg-green-400/85 mb-4"
            type="submit"
          >
            Start
          </button>
          <button
            className="bg-amber-500/65 rounded-xl p-4 hover:bg-amber-400/85"
            type="button"
            onClick={handleNavigateToLeaderboard}
          >
            Check the Leaderboard
          </button>
        </div>
      </form>
    </div>
  );
};
