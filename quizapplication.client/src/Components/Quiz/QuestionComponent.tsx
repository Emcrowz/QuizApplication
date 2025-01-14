import React from "react";
import { Question } from "../../Models/Question";
import { Choises } from "./Choises";
import { QuizAction } from "../../Interfaces/QuizAction";

interface QuestionProps {
  question: Question;
  dispatch: React.ActionDispatch<[action: QuizAction]>;
  index: number;
  numberOfQuestions: number;
}

export const QuestionComponent: React.FC<QuestionProps> = ({
  question,
  dispatch,
  index,
  numberOfQuestions,
}) => {
  return (
    <div className="">
      <h1>{question.title}</h1>
      <Choises
        question={question}
        dispatch={dispatch}
        index={index}
        numberOfQuestions={numberOfQuestions}
      />
    </div>
  );
};