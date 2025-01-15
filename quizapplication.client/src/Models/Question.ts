import { QuestionType } from "../Constants/QuestionType";

export interface Question {
  type: QuestionType;
  title: string;
  choises: string[];
  correctOptions: string[];
  points: number;
}
