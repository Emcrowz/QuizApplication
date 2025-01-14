import { QuizActionType } from "../../Constants/QuizActionType";
import { QuizAction } from "../../Interfaces/QuizAction";

interface ChoisesAnswerButtonProps {
  dispatch: React.ActionDispatch<[action: QuizAction]>;
  index: number;
  numberOfQuestions: number;
  selectedAnswers: string[];
}

export const ChoisesAnswerButton: React.FC<ChoisesAnswerButtonProps> = ({
  dispatch,
  index,
  numberOfQuestions,
  selectedAnswers,
}) => {
  if (index < numberOfQuestions - 1) {
    return (
      <button
        className="bg-cyan-500/40 rounded-lg p-4 hover:bg-cyan-400/80"
        type="button"
        onClick={() =>
          dispatch({
            type: QuizActionType.QuestionAnswered,
            payload: selectedAnswers,
          })
        }
      >
        Next Question
      </button>
    );
  }

  if (index === numberOfQuestions - 1) {
    return (
      <button
            className="bg-cyan-500/40 rounded-lg p-4 over:bg-green-400/85"
        type="button"
        onClick={() =>
          dispatch({
            type: QuizActionType.QuestionAnsweredFinal,
            payload: selectedAnswers,
          })
        }
      >
        Finish Quiz
      </button>
    );
  }
};
