import { AxiosInstance } from "../../../Config/AxiosInstance";
import { Question } from "../../../Models/Question";

export const getQuestions = async (): Promise<Question[]> =>
  (await AxiosInstance.get("/questions/getall")).data;
