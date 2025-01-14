import { QuestionType } from "../constants/QuestionType";

export interface QuestionModel {
    type: QuestionType;
    title: string;
    choises: string[];
    correctOptions: string[];
    points: number;
}