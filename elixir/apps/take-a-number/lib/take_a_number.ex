defmodule TakeANumber do
  def start() do
    spawn(fn -> loop(0) end)
  end

  defp loop(state) do
    receive do
      {:report_state, sender_pid} ->
        send(sender_pid, state)
        |> loop()

      {:take_a_number, sender_pid} ->
        send(sender_pid, state + 1)
        |> loop()

      :stop ->
        :ok

      _ ->
        loop(state)
    end
  end
end
