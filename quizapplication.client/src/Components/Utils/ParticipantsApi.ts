import { AxiosInstance } from "../../Config/AxiosInstance";
import { Participant } from "../../Models/Participant";

export const postParticipant = async (
  participant: Participant
): Promise<Participant> =>
  (await AxiosInstance.post("/participants/postsingle", participant)).data;

export const getTopTenParticipants = async (): Promise<Participant[]> =>
  (await AxiosInstance.get("/participants/gettop")).data;
