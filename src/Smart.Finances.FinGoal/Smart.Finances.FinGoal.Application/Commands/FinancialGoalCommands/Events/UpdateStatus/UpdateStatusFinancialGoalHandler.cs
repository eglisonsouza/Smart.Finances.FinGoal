using MediatR;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus.Commands;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.ViewModels;
using Smart.Finances.FinGoal.Core.Exceptions;
using Smart.Finances.FinGoal.Core.Models.Entities;
using Smart.Finances.FinGoal.Core.Repositories;

namespace Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Events.UpdateStatus
{
    public class UpdateStatusFinancialGoalHandler(IFinancialGoalRepository repository) :
        IRequestHandler<CancellFinancialGoalCommand, FinancialGoalViewModel>,
        IRequestHandler<CompletedFinancialGoalCommand, FinancialGoalViewModel>,
        IRequestHandler<HoldFinancialGoalCommand, FinancialGoalViewModel>,
        IRequestHandler<BackFinancialGoalCommand, FinancialGoalViewModel>
    {
        private readonly IFinancialGoalRepository _repository = repository;

        public async Task<FinancialGoalViewModel> Handle(CancellFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            entity!.Cancell();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModel> Handle(CompletedFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            entity!.Completed();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModel> Handle(HoldFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            entity!.Hold();
            return await ExecuteAsync(entity);
        }

        public async Task<FinancialGoalViewModel> Handle(BackFinancialGoalCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request.Id);
            entity!.Back();
            return await ExecuteAsync(entity);
        }

        private async Task<FinancialGoalViewModel> ExecuteAsync(FinancialGoal entity)
        {
            _repository.Update(entity);
            return FinancialGoalViewModel.FromEntity(entity);
        }

        private Task<FinancialGoal?> GetEntity(Guid id)
        {
            return _repository.GetById(id) ?? throw new EntityNotFoundException();
        }
    }
}
