#!/bin/bash
export ASPNETCORE_ENVIRONMENT=local
cd src/DShop.Monolith.Api
dotnet run --no-restore