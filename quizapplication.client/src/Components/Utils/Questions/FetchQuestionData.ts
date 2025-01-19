import { getQuestions } from "./QuestionsApi";
import { QuizActionType } from "../../../Constants/QuizActionType";
import { QuizAction } from "../../../Interfaces/QuizAction";

export const FetchQuestionData = async (
  dispatch: React.ActionDispatch<[action: QuizAction]>
) => {
  try {
    const data = await getQuestions();
    dispatch({ type: QuizActionType.DataReceived, payload: data });
  } catch (error) {
    if (error instanceof Error) {
      dispatch({ type: QuizActionType.DataFail, payload: error.message });
    } else {
      dispatch({
        type: QuizActionType.DataFail,
        payload: "An unknown error occurred.",
      });
    }
  }
};
