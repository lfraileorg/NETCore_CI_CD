
# Demo for Inmersion workshop

## Introduction

Here we are supposed to talk about the different things on the project :)

# CI/CD Statuses

[![(NO DOCKER)CI/CD .Net Core](https://github.com/lfraileorg/NETCore_CI_CD/actions/workflows/no_docker_ci_cd.yml/badge.svg)](https://github.com/lfraileorg/NETCore_CI_CD/actions/workflows/no_docker_ci_cd.yml)

## Automated Workflows

This repository uses GitHub Actions Agentic Workflows to automate maintenance tasks:

### Daily Documentation Updater

**Workflow**: [`daily-doc-updater`](.github/workflows/daily-doc-updater.md)

Automatically scans for merged pull requests and code changes from the last 24 hours, identifies features that need documentation, and creates pull requests to update the documentation accordingly.

- **Schedule**: Runs daily at 12:35 UTC
- **Trigger**: Can be manually triggered via workflow_dispatch
- **Output**: Creates pull requests with documentation updates
- **Labels**: `documentation`, `automation`

### Daily Repo Status

**Workflow**: [`daily-repo-status`](.github/workflows/daily-repo-status.md)

Creates daily status reports as GitHub issues, gathering recent repository activity including issues, PRs, discussions, releases, and code changes with productivity insights and recommendations.

- **Schedule**: Runs daily at 17:50 UTC
- **Trigger**: Can be manually triggered via workflow_dispatch
- **Output**: Creates GitHub issues with status reports
- **Labels**: `report`, `daily-status`


