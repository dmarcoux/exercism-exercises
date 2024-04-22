# Use the Plot struct as it is provided
defmodule Plot do
  @enforce_keys [:plot_id, :registered_to]
  defstruct [:plot_id, :registered_to]
end

defmodule CommunityGarden do
  def start(_opts \\ []) do
    Agent.start(fn -> [plots: [], next_plot_id: 1] end)
  end

  def list_registrations(pid) do
    Agent.get(pid, fn [{:plots, plots}, _] -> plots end)
  end

  def register(pid, register_to) do
    Agent.get_and_update(pid, fn [plots: plots, next_plot_id: next_plot_id] ->
      plot = %Plot{plot_id: next_plot_id, registered_to: register_to}

      {plot, [plots: [plot | plots], next_plot_id: next_plot_id + 1]}
    end)
  end

  def release(pid, plot_id) do
    Agent.update(pid, fn [plots: plots, next_plot_id: next_plot_id] ->
      [
        plots: Enum.reject(plots, fn plot -> plot.plot_id == plot_id end),
        next_plot_id: next_plot_id
      ]
    end)
  end

  def get_registration(pid, plot_id) do
    Agent.get(pid, fn [{:plots, plots}, _] ->
      Enum.find(
        plots,
        {:not_found, "plot is unregistered"},
        fn plot -> plot.plot_id == plot_id end
      )
    end)
  end
end
